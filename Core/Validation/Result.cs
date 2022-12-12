namespace Core.Validation;

public class Result
{
    public Result()
    {
        ValidationResults = new List<ValidationResult>();
        InfoMessages = new List<string>();
    }
    
    public List<ValidationResult> ValidationResults;
    public List<string> InfoMessages { get; set; }
    public string SuccesMessage { get; set; }

    public Result AddValidationResult(string key, string message)
    {
        ValidationResults.Add(new ValidationResult()
        {
            ValidationKey = key,
            Message = message,
        });

        return this;
    }
    
    public void AddValidationResults(List<ValidationResult> results)
    {
        ValidationResults.AddRange(results);
    }

    public string ErrorMessageStrings()
    {
        return ValidationResults.Any() ? String.Join(", ", ValidationResults.Select(x => x.Message)) : "";
    }        
    
    public List<string> ErrorMessageStringArray()
    {
        return ValidationResults.Any() ? ValidationResults.Select(x => x.Message).ToList() : new List<string>();
    }
    
    public bool Success => !ValidationResults.Any();
    public bool Failure => ValidationResults.Any();
    
    
    public static Result Ok()
    {
        return new Result();
    }
    public static Result Fail()
    {
        var res = new Result();
        res.AddValidationResult("error", "error");
        return res;
    }
    public static Result Fail(string message)
    {
        var res = new Result();
        res.AddValidationResult("error", message);
        return res;
    }
    
    public static Result Ok(string message)
    {
        var res = new Result()
        {
            SuccesMessage = message
        };
        
        return res;
    }
    
    public static Result<T> Ok<T>(T value)
    {
        return new Result<T>(value);
    }
    public static Result<T> Fail<T>(T value)
    {
        var res = new Result<T>(value);
        res.AddValidationResult("error", "error");
        return res;
    }
    public static Result<T> Fail<T>(T value, string errormessage)
    {
        var res = new Result<T>(value);
        res.AddValidationResult("error", errormessage);
        return res;
    }
    public static Result<T> Fail<T>(T value, string errorkey, string errormessage)
    {
        var res = new Result<T>(value);
        res.AddValidationResult(errorkey, errormessage);
        return res;
    }
    
    public static Result<T> Ok<T>(T value, string succesMessage)
    {
        var res = new Result<T>(value)
        {
            SuccesMessage = succesMessage
        };
        return res;
    }
    
}

public class Result<T> : Result
{
    public T Value { get; }

    public Result(T value)
    {
        Value = value;
    }
}

public class ValidationResult
{
    public string ValidationKey { get; set; }
    public string Message { get; set; }
}