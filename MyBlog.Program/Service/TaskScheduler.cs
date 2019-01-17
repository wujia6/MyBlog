using System;
using System.Collections.Generic;
using System.Text;
using MyBlog.Domain.Data;
using MyBlog.Domain.Service;
using MyBlog.IComm;

namespace MyBlog.Application.Service
{
    public class TaskScheduler<T> where T: class
    {
        private readonly BlogContext blogContext;
        private readonly IDomainService<T> iDomain;

        public TaskScheduler(BlogContext cxt, IDomainService<T> idomain)
        {
            blogContext = cxt;
            iDomain = idomain;
        }


    }
}
