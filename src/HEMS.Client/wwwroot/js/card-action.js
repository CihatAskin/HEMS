
let categories = document.querySelectorAll('div.category .dashboard-card .card-header');
let pTypes = document.querySelectorAll('div.product-type .dashboard-card .card-header');

categories.forEach(x => {

    x.addEventListener("click", () => {
      
        showAll();

        var parent = x.closest('.dashboard-card');     
        parent.classList.add('active');

        let types = document.querySelectorAll(`div.product-type .dashboard-card:not([data-category="${parent.dataset.code}"]`);
        types.forEach(typ =>
            typ.classList.add('d-none')
        );

        let products = document.querySelectorAll(`div.product .dashboard-card:not([data-category="${parent.dataset.code}"]`);
        products.forEach(typ =>
            typ.classList.add('d-none')
        );

        setTimeout(() => {
            document.addEventListener("click", onDocumentClick);
        }, 4);
    });
});

pTypes.forEach(x => {

    x.addEventListener("click", () => {

        showAllProducts();
        clearAllProductTypes();

        var parent = x.closest('.dashboard-card');
        parent.classList.add('active');

        let products = document.querySelectorAll(`div.product .dashboard-card:not([data-type="${parent.dataset.code}"]`);
        products.forEach(typ =>
            typ.classList.add('d-none')
        );

        setTimeout(() => {
            document.addEventListener("click", onDocumentClick);
        }, 4);
    });
});

let showAll = () => {

    let cards = document.querySelectorAll('.dashboard-card');
    cards.forEach(x => {
        x.classList.remove('d-none');
        x.classList.remove('active');
    });
}

let showAllProducts = () => {

    let cards = document.querySelectorAll('.product .dashboard-card');
    cards.forEach(x => {
        x.classList.remove('d-none');
    });
}
let clearAllProductTypes= () => {

    let cards = document.querySelectorAll('.product-type .dashboard-card');
    cards.forEach(x => {
        x.classList.remove('active');
    });
}

let onDocumentClick = (e) => {
    let target = e.target;

    let card = target.closest(".dashboard-card");

    if (card) {
        return;
    }
    showAll();
    document.removeEventListener("click", onDocumentClick, false);
};