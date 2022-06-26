
namespace HEMS.Domain
{
    public static class Procedures
    {
        public static class Category
        {
            public static string DELETE => "sp_category_delete";
            public static string GET_ALL => "sp_category_get_all";
            public static string GET_BY_ID => "sp_category_get_by_id";
            public static string INSERT => "sp_category_insert";
            public static string UPDATE => "sp_category_update";
            public static string IS_EXIST => "sp_category_is_exist";
            public static string INSERT_OR_REVIEW => "sp_category_insert_or_revive";
        }

        public static class ProductType
        {
            public static string DELETE => "sp_product_type_delete";
            public static string GET_ALL => "sp_product_type_get_all";
            public static string GET_BY_CATEGORY => "sp_product_type_get_by_category";
            public static string GET_BY_ID => "sp_product_type_get_by_id";
            public static string INSERT => "sp_product_type_insert";
            public static string UPDATE => "sp_product_type_update";
            public static string IS_EXIST => "sp_product_type_is_exist";
            public static string INSERT_OR_REVIEW => "sp_product_type_insert_or_revive";
        }

        public static class Product
        {
            public static string DELETE => "sp_product_delete";
            public static string GET_ALL => "sp_product_get_all";
            public static string GET_BY_ID => "sp_product_get_by_id";
            public static string INSERT => "sp_product_insert";
            public static string UPDATE => "sp_product_update";
            public static string IS_EXIST => "sp_product_is_exist";
            public static string INSERT_OR_REVIEW => "sp_product_insert_or_revive";
            public static string GET_BY_TYPE => "sp_product_get_by_type";

        }
    }
}
