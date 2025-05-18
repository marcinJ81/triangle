using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading;
using Triangle3.Figures;
using Triangle3.Menu;

namespace Triangle3
{
	internal class Program
	{
        static void Main(string[] args)
		{
            var menuHandler = new MenuHandler();
            menuHandler.Run();
        }
	}
	
}
