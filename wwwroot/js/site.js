document.addEventListener("DOMContentLoaded", function () {
    const toggleButton = document.getElementById("toggleTheme");
    const body = document.body;
    const isDarkMode = localStorage.getItem("darkMode") === "enabled";

    if (isDarkMode) {
        body.classList.add("dark-mode");
    }

    toggleButton.addEventListener("click", function () {
        body.classList.toggle("dark-mode");

        if (body.classList.contains("dark-mode")) {
            localStorage.setItem("darkMode", "enabled");
        } else {
            localStorage.setItem("darkMode", "disabled");
        }
    });
});
