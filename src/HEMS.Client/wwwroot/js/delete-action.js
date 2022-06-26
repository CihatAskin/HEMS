
let $error = document.getElementById('error');
let deleteLinks = document.querySelectorAll('.delete-link');

deleteLinks.forEach(t => {

    t.addEventListener('click', (e) => {
        doGet(t.dataset.link, (req) => {

            var message = JSON.parse(req.responseText).messages;
            $error.innerHTML = '';

            $error.textContent = message;
            if (!message) {
                window.location.reload();
            }
            window.scrollTo({ top: 0, behavior: 'smooth' });
        });
    });
});