using NewMYYT.Core.Model;
using NewMYYT.Core.Service;
using NewMYYT.CoreWebApi.ViewModels.Input;

namespace NewMYYT.CoreWebApi.Controllers
{
    /// <summary>
    /// generic crud controller for entities where there is no difference between the edit and create view
    /// </summary>
    /// <typeparam name="TEntity">the entity</typeparam>
    /// <typeparam name="TInput"> viewmodel </typeparam>
    public abstract class Cruder<TEntity, TInput> : Crudere<TEntity,TInput,TInput>
        where TInput : Input, new()
        where TEntity : DelEntity, new()
    {
        public Cruder(ICrudService<TEntity> service) : base(service)
        {
        }
        
        protected override string EditView
        {
            get { return "create"; }
        }
    }
}