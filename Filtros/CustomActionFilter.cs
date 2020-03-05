using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Filtros
{
    public class CustomActionFilter: ActionFilterAttribute
    {

        /*Antes de que se ejecute el action result del controlador*/
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            WriteValues(filterContext.Controller,
                filterContext.ActionDescriptor,
                filterContext.RouteData);
        }
        /*Despues de que se ejecute el action result del controlador*/
        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            WriteValues(filterContext.Controller,
                filterContext.ActionDescriptor,
                filterContext.RouteData);
        }

        /*Este medoto es util para realizar acciones de logueo y manejo de cache*/
        /*Antes de que se ejecute el metodo que devuelve el resultado*/
        /*Es invocado justo antes de que la instancia de actionresult que es devuelta por la accion sea invocada*/
        public override void OnResultExecuting(ResultExecutingContext filterContext)
        {
            WriteValues(filterContext.Controller,
                  null,
                  filterContext.RouteData);
        }


        /*Este medoto es util para realizar acciones de logueo y manejo de cache*/
        /*Es invocado justo despues de que la instancia de actionresult que es devuelta por la accion sea invocada*/
        public override void OnResultExecuted(ResultExecutedContext filterContext)
        {
            WriteValues(filterContext.Controller,
                     null,
                     filterContext.RouteData);
        }
        private void WriteValues(ControllerBase controllerBase, ActionDescriptor actionDescriptor, RouteData routeData,[CallerMemberName] string methodName="")
        {
            string Message = string.Format("Evento disparado: {0}", methodName);
            Debug.WriteLine(Message, "CustomActionFilter");
            string ActionName =
                actionDescriptor != null ? actionDescriptor.ActionName : "";
            Message = string.Format("Controller: {0} Action: {1}",controllerBase,ActionName);
            Debug.WriteLine("Controlador y Accion");

            foreach(var KeyValue in routeData.Values)
            {
                Message = String.Format("Key: {0}, Value: {1}",KeyValue.Key, KeyValue.Value);
                Debug.WriteLine(Message,"Dato de la ruta");
            }

        }
    }
}