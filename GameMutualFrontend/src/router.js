import { createRouter, createWebHistory } from 'vue-router';
import MutualGame from './pages/MutualGame';

import CompareGamesContainer from './components/CompareGamesContainer.vue';
import SearchUserComponent from './components/SearchUserComponent.vue';

const routes = [
  { path: '/', component: MutualGame },
  { path: '/games', component: MutualGame },
  { path: '/test', component: CompareGamesContainer, SearchUserComponent}
];

const router = createRouter({
  history: createWebHistory(),
  routes,
});

export default router;
