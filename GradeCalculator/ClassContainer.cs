using Autofac;
using GradeCalculator.Interfaces;
using GradeCalculator.Services;

namespace GradeCalculator
{
    static class ClassContainer
    {
        /// <summary>Contains classes to resolve.</summary>
        public static IContainer Container { get; set; }

        static ClassContainer()
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<BrokenLineFormula>().As<IBrokenLineFormula>();
            builder.RegisterType<ParabolicFormula>().As<IParabolicFormula>();
            builder.RegisterType<GradeListPdf>().As<IGradeListPdf>();

            Container = builder.Build();
        }
    }
}