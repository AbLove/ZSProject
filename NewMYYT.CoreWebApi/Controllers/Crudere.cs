using Microsoft.AspNetCore.Mvc;
using NewMYYT.Core;
using NewMYYT.Core.Model;
using NewMYYT.Core.Service;
using NewMYYT.CoreWebApi.ViewModels.Input;

namespace NewMYYT.CoreWebApi.Controllers
{
    /// <summary>
    /// generic crud controller for entities where there is difference between the edit and create view;
    /// used to do crud with both the grid and the ajaxlist
    /// </summary>
    /// <typeparam name="TEntity"> the entity</typeparam>
    /// <typeparam name="TCreateInput">create viewmodel</typeparam>
    /// <typeparam name="TEditInput">edit viewmodel</typeparam>
    public abstract class Crudere<TEntity, TCreateInput, TEditInput> : Controller
        where TCreateInput : new()
        where TEditInput : Input, new()
        where TEntity : DelEntity, new()
    {
        protected readonly ICrudService<TEntity> service;

        protected virtual string EditView
        {
            get { return "edit"; }
        }

        public Crudere(ICrudService<TEntity> service)
        {
            this.service = service;
        }

        [HttpPost]
        public ActionResult Create(TCreateInput input, bool? usingAjaxList)
        {
            if (!ModelState.IsValid)
                return View(input);

            var id = service.Create(new TEntity());
            var entity = service.Get(id);
            
            return Json(MapEntityToGridModel(entity));
        }

        [HttpPost]
        public virtual ActionResult Edit(TEditInput input, bool? usingAjaxList)
        {
            try
            {
                if (!ModelState.IsValid)
                    return View(EditView, input);

                var entity = new TEntity();
                service.Save();
                return Json(MapEntityToGridModel(entity));
                
            }
            catch (MYYTException ex)
            {
                return Content(ex.Message);
            }
        }
        [HttpDelete]
        public ActionResult Delete(int id, string gridId)
        {
            return View("ConfirmDelete", new DeleteConfirmInput
                {
                    Id = id,
                    Message = "",
                    GridId = gridId // gridId,id is needed to emphasize (make it yellow) the row in question
                });
        }

        [HttpPost]
        public ActionResult Delete(DeleteConfirmInput input)
        {
            service.Delete(input.Id);
            return Json(new { input.Id});
        }

        /// <summary>
        /// used by the grid and by Create and Edit Actions to return a grid item model so the grid could use it to render a row
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        [NonAction]
        protected virtual object MapEntityToGridModel(TEntity entity)
        {
            return entity;
        }


        /// <summary>
        /// used by the AjaxList to render an item, also Create,Edit and Restore actions use it to render an item and return it to the ajaxlist so it would be updated
        /// </summary>
        protected virtual string RowViewName 
        {
            get
            {
                return string.Empty;
            } 
        }
    }
}