using ErrorOr;
using MediatR;
using MercuryProject.Application.Common.Interfaces.Persistence;
using MercuryProject.Application.Product.Common;
using MercuryProject.Domain.Common.Errors;
using Microsoft.AspNetCore.Http.Features;


namespace MercuryProject.Application.Product.Commands.Create
{
    internal class ProductCreateCommandHandler : IRequestHandler<ProductCreateCommand, ErrorOr<ProductResult>>
    {
        private readonly IProductRepository _productRepository;
        private readonly IUserRepository _userRepository;

        public ProductCreateCommandHandler(IProductRepository productRepository, IUserRepository userRepository)
        {
            _productRepository = productRepository;
            _userRepository = userRepository;
        }

        public async Task<ErrorOr<ProductResult>> Handle(ProductCreateCommand request, CancellationToken cancellationToken)
        {
            await Task.CompletedTask;

            if (await _productRepository.GetProductByName(request.Name) is not null)
            {
                return Errors.Product.DuplicateProductName;
            }

            List<string> pathsToImage = new();

            if (request.Files != null && request.Files.Count > 0)
            {
                foreach (var file in request.Files)
                {
                    if (file.Length > 0)
                    {
                        string projectPath = AppDomain.CurrentDomain.BaseDirectory;
                        string solutionPath = projectPath;
                        while (!Directory.GetFiles(solutionPath, "*.sln").Any())
                        {
                            solutionPath = Directory.GetParent(solutionPath)?.FullName;
                            if (solutionPath == null)
                            {
                                break;
                            }
                        }

                        string folderPath = Directory.GetParent(solutionPath).FullName;
                        string targetFolderPath = "MercuryProject-frontend-Own\\src\\resources";
                        string absolutePath = Path.Combine(folderPath, targetFolderPath);

                        string uploadPath = Path.Combine(absolutePath, "productImages", request.Name);

                        // Путь для сохранения файла на диске
                        string filePath = Path.Combine(uploadPath, file.FileName);

                        if (!Directory.Exists(uploadPath))
                        {
                            Directory.CreateDirectory(uploadPath);
                        }


                        using (var stream = new FileStream(filePath, FileMode.Create))
                        {
                            file.CopyTo(stream);
                        }

                        pathsToImage.Add(file.FileName);
                    }
                }
            }


            var userId = _userRepository.GetUserId();

            var product = Domain.Product.Product.Create(
                userId,
                request.Name,
                request.Description,
                request.Price,
                request.Stock,
                request.Category,
                pathsToImage
                );

            _productRepository.Add(product);

            return new ProductResult(product);
        }
    }
}
