$(document).ready(function () {
    setStatus();


});

function status(element) { // Remove the "active" class from all li elements
    // Remove the "active" class from all li elements
    var listItems = document.querySelectorAll('#sidenav-list li');
    listItems.forEach(function (li) {
        li.classList.remove('active');
    });

    element.parentElement.classList.add('active');
}

function setStatus() {
    var listItems = document.querySelectorAll('#sidenav-list .mainlist-item');
    var currentPage = window.location.pathname;

    const adminArray = ["User", "Lab"];

    listItems.forEach(function (mainListItem) {
        var mainLink = mainListItem.querySelector('a');
        var mainLinkHref = mainLink.getAttribute('href');
        var sublist = mainListItem.querySelector('.sublist');
        var isActive = false;
        if (sublist) {
            var subLinks = sublist.querySelectorAll('a');
            subLinks.forEach(function (subLink) {
                var subLinkHref = subLink.getAttribute('href');   

                if (currentPage.includes(subLinkHref)) {
                    console.log("active");
                    mainListItem.classList.add('active');
                    subLink.parentElement.classList.add('active');
                    isActive = true;
                }
            });
        }

        if (isActive || (mainLink && currentPage.includes(mainLinkHref))) {
            mainListItem.classList.add('active');
            console.log("test1");
        } else if (adminArray.some(item => currentPage.includes(item.toLowerCase()))) {
            mainListItem.classList.add('active');
            console.log("test2");
        } else {
            mainListItem.classList.remove('active');
            console.log("false", isActive);
        }
    });

}
