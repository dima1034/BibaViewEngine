﻿using System.Reflection;

namespace BibaViewEngine.Models
{
    public class ComponentModule
    {
        private readonly Component _component;
        private readonly string _template;

        public Component Component
        {
            get
            {
                return _component;
            }
        }
        public string Template
        {
            get
            {
                return _template;
            }
        }
        public string Name
        {
            get
            {
                return _component.GetType().Name;
            }
        }
        public string TemplateLocation { get; private set; }

        public ComponentModule(Component component)
        {
            _component = component;
            var test = component.GetType().GetTypeInfo().Assembly.Location;

            TemplateLocation = test;
        }
    }
}
