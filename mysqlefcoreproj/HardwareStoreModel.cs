namespace mysqlefcore
{
    public class Tool
    {
        public string ID { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public virtual Brand Brand { get; set; }
        public virtual Category Category { get; set; }
    }

    public class Brand
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Tool> Tools { get; set; }
    }

    public class Category
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Tool> Tools { get; set; }
    }
}