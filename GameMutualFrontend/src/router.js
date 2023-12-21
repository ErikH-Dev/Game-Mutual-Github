import { createRouter, createWebHistory } from 'vue-router';
import { useAuth0 } from '@auth0/auth0-vue';

import MutualGame from './pages/MutualGame';
import ProfilePage from './pages/ProfilePage';
import SettingsPage from './pages/SettingsPage';

const routes = [
  { 
    path: '/', 
    component: MutualGame 
  },
  { 
    path: '/profile', 
    component: ProfilePage,
  },
  {
    path: '/settings',
    component: SettingsPage,
    meta: { requiresAuth: true }
  }
];

const router = createRouter({
  history: createWebHistory(),
  routes,
});

router.beforeEach((to, from, next) => {
  const { isAuthenticated } = useAuth0();

  if (to.matched.some(record => record.meta.requiresAuth) && !isAuthenticated.value) {
      next('/');
  } else {
      next();
  }
});

export default router;
