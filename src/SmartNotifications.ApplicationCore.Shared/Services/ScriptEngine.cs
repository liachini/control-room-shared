using System.Globalization;
using System.Reflection;
using System.Text;
using Microsoft.CodeAnalysis.CSharp.Scripting;
using Microsoft.CodeAnalysis.Scripting;
using Microsoft.Extensions.Logging;

namespace SCM.SmartNotifications.ApplicationCore.Shared.Services;

public class ScriptEngine : IScriptEngine
{
    private readonly ILogger<ScriptEngine> _logger;

    public ScriptEngine(ILogger<ScriptEngine> logger)
    {
        _logger = logger;
    }

    public async Task<T> EvaluateAsync<T>(string expression, object expandoObject, CancellationToken cancellationToken)
    {
        try
        {
            ScriptOptions options = AddDefaultImports();
            Globals globals = new Globals
            {
                context = expandoObject
            };
            T result = await CSharpScript.EvaluateAsync<T>(expression, options, globals,
                cancellationToken: cancellationToken);

            return result;
        }
        catch (Exception e)
        {
            _logger.LogError(e, "Error evaluating expression {0}", expression);
            throw;
        }
    }

    private ScriptOptions AddDefaultImports()
    {
        string workingDir = AppContext.BaseDirectory;

        return ScriptOptions.Default.AddImports(
                "System",
                "System.IO",
                "System.Collections.Generic",
                "System.Diagnostics",
                "System.Dynamic",
                "System.Linq",
                "System.Linq.Expressions",
                "System.Text",
                "System.Globalization",
                typeof(CollectionUtilities).Namespace,
                "System.Threading.Tasks")
            .WithReferences(
                typeof(Binder).Assembly,
                typeof(CollectionUtilities).Assembly,
                typeof(Convert).Assembly,
                typeof(CultureInfo).Assembly,
                typeof(Enumerable).Assembly)
            .WithEmitDebugInformation(true)
            .WithFileEncoding(Encoding.UTF8);
    }

    public class Globals
    {
        public dynamic context;
    }
}