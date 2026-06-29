using Microsoft.EntityFrameworkCore.Metadata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ecommerce.app.common
{
    public class Result
    {
        public bool IsSuccess { get; }
        public IReadOnlyList<error> Errors { get; }
        protected Result(bool issiccess, IReadOnlyList<error> errors)
        {
            IsSuccess = issiccess;
            Errors = errors;
        }
        public static Result OK() => new Result(true, Array.Empty<error>());
        public static Result fail(error error) => new Result(false, new[] { error });

        public static Result fail(IReadOnlyList<error> errors) => new Result(false, errors);

    }

    public class Result<t> : Result
    {
        private readonly t _value;
        public t data => IsSuccess ? _value : throw new InvalidOperationException("can not access the value of failed result");
        private Result(t value) : base(true, Array.Empty<error>())
        {
            _value = value;

        }
        private Result(error error) : base(false, new[] { error })

        {
            _value = default;
        }
        private Result(IReadOnlyList<error> errors) : base(false, errors)
        {
            _value = default;

        }

        public static Result<t> OK(t value) => new(value);

        public static Result<t> Fail(error error) => new(error);

        public static Result<t> Fail(IReadOnlyList<error> errors)
            => new(errors);
        public static implicit operator Result<t>(t value) => OK(value);
        public static implicit operator Result<t>(error errors) => Fail( errors);

    }
}
