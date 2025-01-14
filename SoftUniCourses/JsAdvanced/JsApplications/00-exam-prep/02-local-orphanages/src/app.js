import { logout } from './api/users.js';
import { page, render } from './lib.js';
import { getUserData } from './util.js'
import { createView } from './views/create.js';
import { dashboardView } from './views/dashboard.js';
import { detailsView } from './views/details.js';
import { editView } from './views/edit.js';
import { loginView } from './views/login.js';
import { myPostsView } from './views/my-posts.js';
import { registerView } from './views/registger.js';

page(decorateContext);
page('/', dashboardView);
page('/login', loginView);
page('/register', registerView);
page('/create', createView);
page('/posts/:id', detailsView);
page('/edit/:id', editView);
page('/my-posts', myPostsView);



const main = document.querySelector('main');
document.getElementById('logoutBtn').addEventListener('click', onLogout);
updateNav();
page.start();


function decorateContext(ctx, next) {
    ctx.render = renderMain;
    ctx.updateNav = updateNav;

    next();
}

function renderMain(temlateResult) {

    render(temlateResult, main);
}

function updateNav() {
    const userData = getUserData();

    if (userData) {
        document.querySelector('#user').style.display = 'block';
        document.querySelector('#guest').style.display = 'none';


    } else {
        document.querySelector('#user').style.display = 'none';
        document.querySelector('#guest').style.display = 'block';
    }
}

function onLogout() {
    logout();
    updateNav();
    page.redirect('/');
}