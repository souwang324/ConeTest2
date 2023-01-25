using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kitware.VTK;

namespace ConeTest2
{
    class Program
    {
        static void Main(string[] args)
        {
            ConeTest2();
        }

        public static void ConeTest2()
        {
            vtkConeSource consource = vtkConeSource.New();
            vtkPolyDataMapper mapper = vtkPolyDataMapper.New();
            mapper.SetInputConnection(consource.GetOutputPort());
            vtkActor actor = vtkActor.New();
            actor.SetMapper(mapper);

            vtkRenderer renderer = vtkRenderer.New();
            renderer.AddActor(actor);
            renderer.SetBackground(.1, .2, .3);
            renderer.ResetCamera();

            vtkRenderWindow renderWin = vtkRenderWindow.New();
            renderWin.AddRenderer(renderer);

            vtkRenderWindowInteractor interactor = vtkRenderWindowInteractor.New();
            interactor.SetRenderWindow(renderWin);

            vtkCamera camera = renderer.GetActiveCamera();
            vtkLight light = vtkLight.New();
            light.SetColor(1, 1, 0);
            double[] fpt = new double[3];
            fpt = camera.GetFocalPoint();
            double[] loc = new double[3];
            loc = camera.GetPosition();
            light.SetFocalPoint(fpt[0], fpt[1], fpt[2]);
            light.SetPosition(loc[0], loc[1], loc[2]);
            renderer.AddLight(light);
            camera.SetClippingRange(0.1, 10);
            camera.SetFocalPoint(0, 0, 0);
            camera.SetViewUp(0, 1, 0);
            camera.SetPosition(0, 0, 5);

            renderWin.Render();
            interactor.Start();
        }
    }

}
