function status(element) { // Remove the "active" class from all li elements
    // Remove the "active" class from all li elements
    var listItems = document.querySelectorAll('#sidenav-list li');

    listItems.forEach(function (li) {
        li.classList.remove('active');
    });

    element.parentElement.classList.add('active');
}
