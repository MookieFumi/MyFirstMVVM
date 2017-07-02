namespace MyFirstMVVM.Models
{
    public class Beer
    {
        public Beer()
        {
        }

        public Beer(string type, string name)
        {
            Type = type;
            Name = name;
            Image = "http://6dollarshirts.com/image/cache//data/designs/6ds-replacement-thumbnails/allthisbeer-t-shirt-tn-400x400.jpg";
        }

        public string Type { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }

        public override string ToString()
        {
            return $"{nameof(Type)}: {Type}, {nameof(Name)}: {Name}";
        }
    }
}
