using Microsoft.AspNetCore.Mvc;
using Orders.Backend2.UnitsOfWork.Interfaces;

namespace Orders.Backend2.Controllers;

public class GenericController<T> : Controller where T : class
{
    private readonly IGenericUnitOfWork<T> _unitOfWork;

    public GenericController(IGenericUnitOfWork<T> unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
}