(function () {
    const storageKey = "lms-theme";
    const root = document.documentElement;
    const toggle = document.getElementById("themeToggle");

    const setTheme = (theme) => {
        root.setAttribute("data-theme", theme);
        localStorage.setItem(storageKey, theme);

        if (!toggle) {
            return;
        }

        const icon = toggle.querySelector("i");
        if (!icon) {
            return;
        }

        const isDark = theme === "dark";
        icon.className = isDark ? "fa-solid fa-sun" : "fa-solid fa-moon";
        toggle.setAttribute("aria-label", isDark ? "Switch to light mode" : "Switch to dark mode");
    };

    const saved = localStorage.getItem(storageKey);
    const prefersDark = window.matchMedia("(prefers-color-scheme: dark)").matches;
    const defaultTheme = saved ?? (prefersDark ? "dark" : "light");
    setTheme(defaultTheme);

    if (!toggle) {
        return;
    }

    toggle.addEventListener("click", () => {
        const current = root.getAttribute("data-theme") === "dark" ? "dark" : "light";
        setTheme(current === "dark" ? "light" : "dark");
    });
})();
