
var os = new (function () {
    var attributes = function (str) {
        return WinJS_FileUtils.GetFileAttributes (str);
    };

    this.cwd = function () {
        return dotnet.System.Environment.CurrentDirectory;
    };

    this.cd = function (dir) {
        dotnet.System.Environment.CurrentDirectory = dir;
    };

    this.ls = function (path, searchPattern) {
        var strEnum = [];
        if (path) {
            if (searchPattern) {
                strEnum = dotnet.System.IO.Directory.EnumerateFileSystemEntries (path, searchPattern);
            } else {
                strEnum = dotnet.System.IO.Directory.EnumerateFileSystemEntries (path); 
            }
        } else {
            strEnum = dotnet.System.IO.Directory.EnumerateFileSystemEntries (os.cwd ()); 
        }

        var fsobjs = [];

        var e = strEnum.GetEnumerator ();
        while (e.MoveNext ()) {
            var str = e.Current;

            var o = {
                path: str,
                creationTime: dotnet.System.IO.File.GetCreationTime (str).ToString (),
                lastAccessTime: dotnet.System.IO.File.GetLastAccessTime(str).ToString(),
                lastWriteTime: dotnet.System.IO.File.GetLastWriteTime(str).ToString(),
                size: null,
                attributes: {}        
            };
            
            var attr = attributes (str);
            var k = attr.Keys.GetEnumerator ();
            
            while (k.MoveNext ()) {
                var val = WinJS_host.newVar (dotnet.System.Boolean);
                var found = attr.TryGetValue (k.Current, val.out);
                o.attributes[k.Current] = found ? (val.ToString () ==  'True' ? true : false) : found;
            }

            if (!o.attributes.isDirectory) {
                var fi = new dotnet.System.IO.FileInfo(str);
                o.size = fi.Length;
            }

            fsobjs.push (o);
        }

        return fsobjs;
    }

    this.arguments = function () {
        var args = [];
        var len = WinJS_Arguments.Length;

        for (var i = 0; i < len; ++i) {
            args[i] = WinJS_Arguments[i];
        }

        return args;
    }
}) ();