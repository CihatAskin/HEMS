
function doGet(url, onSuccess, isAsync = false) {
    let req = new XMLHttpRequest();
    req.open("GET", url, isAsync);

    req.onreadystatechange = function () {
        if (req.readyState === XMLHttpRequest.DONE) {
            if (199 < req.status && req.status < 300) {
                onSuccess(req);
            } else {
                if (req.status !== 404) {
                    
                    console.error(req.status.toString(), req);
                }
            }
        }
    };
    req.send(null);
}

function createElement(tag, attributes, text) {
    let $element = document.createElement(tag);
    if (attributes) {
        for (let key of Object.keys(attributes)) {
            $element.setAttribute(key, attributes[key]);
        }
    }
    if (text !== undefined && text !== null) $element.innerHTML = text;
    return $element;
}