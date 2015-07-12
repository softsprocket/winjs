// winjs entry point

var console = new (function () {
    this.log = function () {
        for (var ea in arguments) {
            if (typeof arguments[ea] === 'object') {
                var str = JSON.stringify (arguments[ea]);
                dotnet.System.Console.Write (str);

            } else if (typeof arguments[ea] === 'function') {
                dotnet.System.Console.Write ("<function>");
            } else {
                dotnet.System.Console.Write (arguments[ea]);
            }
            dotnet.System.Console.Write (" ");
        }
        dotnet.System.Console.WriteLine ();
    };

    this.read = function () {
        return WinJS_KeyUtil.read ();
    };

    this.readline = function () {
        return dotnet.System.Console.ReadLine ();
    };

}) ();

require (os);




