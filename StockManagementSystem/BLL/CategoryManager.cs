using StockManagementSystem.DAL.Gateway;
using StockManagementSystem.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StockManagementSystem.BLL
{
    public class CategoryManager
    {
        CategoryGateway categoryGateway;

        public CategoryManager()
        {
            categoryGateway = new CategoryGateway();
        }

        // for save category
        public string Save(Category category)
        {
            //first check categoryName alreary exists or not
            if (categoryGateway.IsCategoryNameExists(category.CategoryName))
            {
                return "Category Name already exists";
            }
            else
            {
                // save category
                int rowAffected = categoryGateway.Save(category);

                if (rowAffected > 0)
                {
                    return "Save Successful";
                }
                else
                {
                    return "Save Failed";
                }
            }
        }

        // get all category from gateway
        public List<Category> GetAllCategory()
        {
            return categoryGateway.GetAllCategory();
        }

        public Category GetCategoryById(int id)
        {
            return categoryGateway.GetCategoryById(id);
        }

        // update category by id
        public string UpdateCategoryNameById(Category category)
        {
            //first check categoryName alreary exists or not
            if (categoryGateway.IsCategoryNameExists(category.CategoryName))
            {
                return "Category Name already exists";
            }
            else
            {
                // update category
                int rowAffected = categoryGateway.UpdateCategoryNameById(category);

                if (rowAffected > 0)
                {
                    return "Success";
                }
                else
                {
                    return "Failed";
                }
            }
        }
    }
}