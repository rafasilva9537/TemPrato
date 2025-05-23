document.documentElement.setAttribute('data-theme');    

function themeChangeLight(){
  const newTheme = 'light';
  document.documentElement.setAttribute('data-theme', newTheme);
}

function themeChangeDark() {
  const newTheme = 'dark';
  document.documentElement.setAttribute('data-theme', newTheme);
}