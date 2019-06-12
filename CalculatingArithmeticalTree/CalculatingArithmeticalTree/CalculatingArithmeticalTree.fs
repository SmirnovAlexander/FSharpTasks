module Logic

    exception ZeroDivisionException of string

    // Expression type.
    type Expression =
        | Number of int
        | Addition of Expression * Expression
        | Subtraction of Expression * Expression
        | Multiplication of Expression * Expression
        | Division of Expression * Expression    

    // Evaluating an expression.
    let rec evaluation = function
    | Number(i) -> i
    | Addition(a, b) -> evaluation a + evaluation b
    | Subtraction(a, b) -> evaluation a - evaluation b
    | Multiplication(a, b) -> evaluation a * evaluation b
    | Division(a, b) ->  if (b <> Number 0) then
                            (evaluation a / evaluation b)
                         else 
                            raise (ZeroDivisionException("Division by zero."))