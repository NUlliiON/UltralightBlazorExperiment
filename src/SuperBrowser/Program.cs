using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using ImpromptuNinjas.UltralightSharp.Enums;
using ImpromptuNinjas.UltralightSharp.Safe;

namespace UltralightCsharpSample1
{
    class Program
    {
        private static void Log(LogLevel logLevel, string? msg)
            => Console.WriteLine($"{logLevel.ToString()}: {msg}");

        private static void JsConsoleMessage(IntPtr data, View caller, MessageSource source, MessageLevel level,
            string? message, uint number, uint columnNumber, string? id)
        {
            Console.WriteLine($"JS_CONSOLE:: {level.ToString()}: {message}");
        }

        private static async Task Main(string[] args)
        {
            Ultralight.SetLogger(new Logger {LogMessage = Log});
            AppCore.EnablePlatformFontLoader();
            AppCore.EnablePlatformFileSystem("assets");
            
            var settings = new Settings();
            
            var config = new Config();
            config.SetEnableJavaScript(true);
            config.SetEnableImages(true);
            config.SetResourcePath("resources");
            config.SetCachePath("cache");
            config.SetUseGpuRenderer(true);

            var app = new App(settings, config);
            var monitor = app.GetMainMonitor();
            
            uint windowWidth = app.GetMainMonitor().GetWidth() - 100;
            uint windowHeight = app.GetMainMonitor().GetHeight() - 100;
            var window = new Window(monitor, windowWidth, windowHeight, false, WindowFlags.Titled);
            window.SetTitle("Super browser");
            app.SetWindow(window);
            
            var renderer = app.GetRenderer();
            var session = new Session(renderer, false, "Session1");
            
            var mainView = new View(renderer, windowWidth, windowHeight, true, session);
            mainView.SetAddConsoleMessageCallback(JsConsoleMessage, default);
            mainView.LoadUrl("file:///index.html");
            var mainOverlay = new Overlay(window, mainView, 0, 0);
            mainOverlay.Show();
            app.Run();
        }
    }
}