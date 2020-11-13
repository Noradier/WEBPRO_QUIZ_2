﻿using FireSharp.Config;
using FireSharp.Interfaces;
using FireSharp.Response;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using student_database.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace student_database.Controllers
{
    [Authorize]
    public class StudentController : Controller
    {
        IFirebaseConfig config = new FirebaseConfig
        {
            AuthSecret = "GzGBiH8Rm0MK7C5ZpOQFBvAtTIET50SPjzHiazgV",
            BasePath = "https://student-database-6602f.firebaseio.com/"
        };

        IFirebaseClient client;

        // GET: Student
        public ActionResult Index()
        {
            client = new FireSharp.FirebaseClient(config);
            FirebaseResponse response = client.Get("Students");
            dynamic data = JsonConvert.DeserializeObject<dynamic>(response.Body);
            var list = new List<Student>();
            foreach (var item in data)
            {
                list.Add(JsonConvert.DeserializeObject<Student>(((JProperty)item).Value.ToString()));
            }
            return View(list);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Student student)
        {
            try
            {
                AddStudentToFirebase(student);
                ModelState.AddModelError(string.Empty, "Added Succesfully");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
            }
            return View();
        }

        private void AddStudentToFirebase(Student student)
        {
            client = new FireSharp.FirebaseClient(config);
            var data = student;
            PushResponse response = client.Push("Students/", data);
            data.student_id = response.Result.name;
            SetResponse setResponse = client.Set("Students/" + data.student_id, data);
        }

        [HttpGet]
        public ActionResult Detail(string id)
        {
            client = new FireSharp.FirebaseClient(config);
            FirebaseResponse response = client.Get("Students/"+id);
            Student data = JsonConvert.DeserializeObject<Student>(response.Body);
            return View(data);
        }

        [HttpGet]
        public ActionResult Edit(string id)
        {
            client = new FireSharp.FirebaseClient(config);
            FirebaseResponse response = client.Get("Students/" + id);
            Student data = JsonConvert.DeserializeObject<Student>(response.Body);
            return View(data);
        }

        [HttpPost]
        public ActionResult Edit(Student student)
        {
            client = new FireSharp.FirebaseClient(config);
            SetResponse response = client.Set("Students/" + student.student_id, student);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Delete(string id)
        {
            client = new FireSharp.FirebaseClient(config);
            FirebaseResponse response = client.Delete("Students/" + id);
            return RedirectToAction("Index");
        }
    }
}