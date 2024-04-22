namespace PeopleApp.Mvc.Helpers
{
    public class ApiResult<T> : BaseResult
    {
        public IEnumerable<T> Entiteis { get; set; }
        public T? Entity { get; set; }
    }
}
