namespace Wallet.Web.Controllers
{
    using MediatR;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Wallet.Domain.Handlers.Items;
    using Wallet.Domain.Handlers.Wallet;

    [Authorize]
    public class WalletController : Controller
    {
        private readonly IMediator _mediator;
            
        public WalletController(IMediator mediator)
        {
            _mediator = mediator;
        }

        public IActionResult Index()
        {
            var model = _mediator.Send(new WalletQuery { User = User.Identity.Name });          
            return View( model.Result);
        }

        [HttpPost]
        public IActionResult SaveWallet(SaveWalletCommand command)
        {
            if (!ModelState.IsValid)
                return Json($"Wrong data");

            _mediator.Send(command);
            return RedirectToAction(nameof(Index));
        }


        [HttpPost]
        public IActionResult AddItem(AddItemCommand command)
        {
            if (!ModelState.IsValid)
                return Json($"Wrong data");

            _mediator.Send(command);
            return RedirectToAction(nameof(Index));
        }
        
        public IActionResult DelateItem(DeleteItemCommand command)
        {
            if (!ModelState.IsValid)
                return Json($"Wrong data");

            _mediator.Send(command);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Items(ItemsQuery query)
        {
            if (!ModelState.IsValid)
                return Json($"Wrong data");

            return View(_mediator.Send(query));
        }
    }
}
