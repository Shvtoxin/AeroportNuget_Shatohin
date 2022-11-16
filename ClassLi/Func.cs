namespace ClassLi
{
    public class Func<T> where T : class
    {
        public List<T> Airs = new List<T>();
        public List<T> Get() => Airs;

        public void Add(T air) => Airs.Add(air);

        public void Remove(T air) => Airs.Remove(air);

        public void Change(int index, T air) => Airs[index] = air;


    }
}
