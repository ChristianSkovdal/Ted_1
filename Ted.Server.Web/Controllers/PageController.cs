﻿using System;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using Ted.Server.Data;
using Ted.Server.Exceptions;
using Ted.Server.Models;

namespace Ted.Server.Web.Controllers
{
    [Route("api/[controller]")]
    public class PageController : Controller
    {
        WorkspaceRepository _repo;

        AuthenticationHandler _auth;

        public PageController(WorkspaceRepository repo, AuthenticationHandler auth)
        {
            _repo = repo;
            _auth = auth;
        }

        [HttpGet("{token}/{id}")]
        public JsonResult GetPage(string token, int id)
        {
			var page = _repo.GetPage(id);
			if (page == null)
			{
				throw new TedExeption(ExceptionCodes.PageNotFound);
			}

			if (_auth.AuthenticateForWorkspace(token, page.WorkspaceId)==null)
                throw new TedExeption(ExceptionCodes.Authentication);

            // Avoid cyclic refs
            page.workspace.pages = null;

            return Json(new
			{
				success = true,
				data = page
			});
        }        

        //[HttpPost("{token}/{workspaceId}/{position}")]
        //public void AddComponent(string token, int workspaceId, int position, [FromBody]Component value)
        //{
        //    //var user = _auth.AuthenticateForWorkspace(token, workspaceId);

        //    //if (string.IsNullOrEmpty(value.xtype))
        //    //    throw new ArgumentException(nameof(value.xtype));

        //    //_repo.InsertComponent(value, workspaceId, position, user);

        //    //return Json(new
        //    //{
        //    //    success = true
        //    //});
        //}

        //[HttpDelete("{token}/{workspaceId}/{componentId}")]
        //public void DeleteComponent(string token, int workspaceId, string componentId)
        //{
        //    if (_auth.AuthenticateForWorkspace(token, workspaceId) == null)
        //        throw new TedExeption(ExceptionCodes.Authentication);

        //    _repo.DeleteComponent(workspaceId, componentId);
        //}


    }
}