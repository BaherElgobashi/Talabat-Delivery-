using ECommerce.Domain.Models.Products;
using ECommerce.Shared.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Service.Specifications
{
    public class ProductSpecifications : BaseSpecifications<Product, int>
    {
        // Get All Products Without Filtration.
        public ProductSpecifications(): base(null)
        {
            AddIncludes(p => p.Brand);
            AddIncludes(p => p.Type);
        }

        // Get All Products With BrandId and TypeId Filtration.
        public ProductSpecifications(int? BrandId, int? TypeId , ProductSortingWay? sortingWay) : 
            base(p => (!BrandId.HasValue ||p.BrandId == BrandId) && (!TypeId.HasValue || p.TypeId == TypeId))
        {
            AddIncludes(p => p.Brand);
            AddIncludes(p => p.Type);

            switch (sortingWay) 
            {
                case ProductSortingWay.NameAsc:
                    AddOrderBy(p => p.Name);
                    break;

                case ProductSortingWay.NameDesc:
                    AddOrderByDesc(p => p.Name);
                    break;

                case ProductSortingWay.PriceAsc:
                    AddOrderBy(p => p.Price);
                    break;

                case ProductSortingWay.PriceDesc:
                    AddOrderByDesc(p => p.Price);
                    break;
            }


        }

        // Get Product By Id and add Brand and Type To the Product.
        public ProductSpecifications(int id ):base(p => p.Id == id)
        {
            AddIncludes(p => p.Brand);
            AddIncludes(p => p.Type);
        }
    }
}
