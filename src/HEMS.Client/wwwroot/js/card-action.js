
//let categories = document.querySelectorAll('div.category .dashboard-card .card-header');

//categories.forEach(x => {
//    console.log(1);
//    x.addEventListener("click", () => {
      
//        showAll();

//        x.focus();
//        var parent = x.closest('.dashboard-card');
//        console.log(x, x.dataset.code, 'types', parent);

//        let types = document.querySelectorAll(`div.product-type .dashboard-card:not([data-category="${parent.dataset.code}"],div.product .dashboard-card:not([data-category="${parent.dataset.code}"])`);
//        types.forEach(typ =>
//            console.log(typ)
//        );
//            //typ.classList.add('d-none')

//        setTimeout(() => {
//            document.addEventListener("click", onDocumentClick);
//        }, 4);
//    });



//});

//let showAll = () => {

//    let cards = document.querySelectorAll('.dashboard-card');
//    cards.forEach(x => x.classList.remove('d-none'));

//}

//let onDocumentClick = (e) => {
//    let target = e.target;

//    let card = target.closest(".dashboard-card");

//    if (card) {
//        return;
//    }
//    showAll();
//    document.removeEventListener("click", onDocumentClick, false);
//};