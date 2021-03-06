using System;
using System.Linq;
using System.Collections;

namespace BibaViewEngine.Compiler
{
    public class Evaluator : IDisposable
    {
        private bool disposed = false;

        public static Evaluator Create()
        {
            return new Evaluator();
        }

        public string Evaluate(string expression, object context)
        {
            var currentType = context.GetType();

            foreach (string propertyName in expression.Split('.'))
            {
                var property = currentType.GetProperty(propertyName);
                context = property.GetValue(context, null);
                currentType = context.GetType();
            }

            return context?.ToString() ?? string.Empty;
        }

        public void Dispose()
        {
            if (!disposed)
            {
                GC.SuppressFinalize(this);

                disposed = true;
            }
        }
    }
}