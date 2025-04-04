document.addEventListener("DOMContentLoaded", function () {
    const toggleButton = document.getElementById("toggleTheme");

    // Aplica o tema salvo
    const savedTheme = localStorage.getItem("theme");
    if (savedTheme === "dark") {
        document.body.classList.add("dark-theme");
    }

    toggleButton?.addEventListener("click", function () {
        document.body.classList.toggle("dark-theme");

        if (document.body.classList.contains("dark-theme")) {
            localStorage.setItem("theme", "dark");
        } else {
            localStorage.setItem("theme", "light");
        }
    });
});


//document.addEventListener("DOMContentLoaded", function () {
//    const toggleButton = document.getElementById("toggleTheme");
//    const body = document.body;
//    const isDarkMode = localStorage.getItem("darkMode") === "enabled";

//    if (isDarkMode) {
//        body.classList.add("dark-mode");
//    }

//    toggleButton.addEventListener("click", function () {
//        body.classList.toggle("dark-mode");

//        if (body.classList.contains("dark-mode")) {
//            localStorage.setItem("darkMode", "enabled");
//        } else {
//            localStorage.setItem("darkMode", "disabled");
//        }
//    });
//});

//// teste
