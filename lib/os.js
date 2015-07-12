
var os = new (function () {
    this.cwd = function () {
        return dotnet.System.Environment.CurrentDirectory;
    };

    this.cd = function (dir) {
        dotnet.System.Environment.CurrentDirectory = dir;
    };

    this.ls = function (path, searchPattern) {
        var strs = [];
        if (path) {
            if (searchPattern) {
                //strs = 
            } else {
            
            }
        } else {
        
        }

        return strs;
    }

}) ();