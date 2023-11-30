<template>
  <div id="main-content" :style="mainContentStyles">
    <div class="compare-container">
      <h1>Enter two Steam user IDs.</h1>
      <div>
        <input v-model="firstUserID" type="text" placeholder="First User ID">
        <input v-model="secondUserID" type="text" placeholder="Second User ID">
      </div>
      <button @click="getGames">Fetch Games</button>
    </div>
    <div v-if="isLoading" class="loading-spinner">
        <div class="custom-loader"></div>
      </div>
    <div class="games-container" v-if="!isLoading">
      <div class="game-item" v-for="(game, index) in games" :key="index">
        <div class="game-card" :style="{ backgroundImage: `url(${getGameImageURL(game.appid)})` }">
          <!-- <div class="game-title">{{ game.name }}</div> -->
        </div>
      </div>
    </div>
    <p>{{ myJson }}</p>
  </div>
</template>

<script>
export default {
  name: 'CompareGames',
  data() {
    return {
      myJson: '',
      games: [],
      isLoading: false,
    };
  },
  methods: {
    async getGames() {
      this.isLoading = true;
      try {
        const response = await fetch(`https://localhost:7257/api/SteamGame/GetMutuallyOwnedGames/${this.firstUserID},${this.secondUserID}`);
        const data = await response.json();
        this.games = data;
        this.myJson = JSON.stringify(data, null, 2);
      } catch (error) {
        console.error('Error fetching data:', error);
        this.myJson = 'Error fetching data';
      } finally {
        this.isLoading = false;
      }
    },
    getGameImageURL(appid) {
      return `https://cdn.cloudflare.steamstatic.com/steam/apps/${appid}/hero_capsule.jpg`;
    },
  },
  props: ['isSidebarOpen'],
  computed: {
    mainContentStyles() {
      return {
        marginLeft: this.isSidebarOpen ? '240px' : '60px',
        transition: 'margin-left 0.25s ease-in-out',
      };
    },
  },
};
</script>
<style>
.loading-spinner {
  display: grid;
  justify-content: center;
}
.custom-loader {
    width: 100px;
    height: 100px;
    display: grid;
}
.custom-loader::before,
.custom-loader::after {    
    content:"";
    grid-area: 1/1;
    --c: radial-gradient(farthest-side,var(--primary-accent) 92%,#0000);
    background: 
      var(--c) 50%  0, 
      var(--c) 50%  100%, 
      var(--c) 100% 50%, 
      var(--c) 0    50%;
    background-size: 24px 24px;
    background-repeat: no-repeat;
    animation: s2 1s infinite;
}
.custom-loader::before {
  margin:8px;
  filter:hue-rotate(45deg);
  background-size: 16px 16px;
  animation-timing-function: linear
}

@keyframes s2{ 
  100%{transform: rotate(.5turn)}
}
.compare-container {
  display: flex;
  flex-direction: column;
  justify-content: center;
  align-items: center; 
  width: 100%;
  background-color: var(--secondary-accent);
  color: #fff;
  padding: 1rem 2rem 1rem 2rem;
  border-radius: 20px;
  margin-bottom: 15px;
}
.games-container {
  display: grid;
  grid-template-columns: repeat(auto-fill, minmax(374px, 1fr));
  grid-gap: 10px;
}

.game-card {
  width: 374px;
  height: 448px;
  background-size: cover;
  background-position: center;
  display: flex;
  flex-direction: column;
  align-items: center;
  text-align: center;
  color: white;
  border-radius: 20px;
  transition: ease-in-out 100ms;
  box-shadow: #11111140 10px 10px 5px;

}
.game-card:hover {
  scale: 1.05;
}

.game-title {
  background-color: rgba(0, 0, 0, 0.6);
  width: 100%;
  padding: 10px;
  text-align: center;
}
input {
  border: 0px solid var(--primary-accent);
  border-radius: 15px;
  padding: 1rem;
  margin: 10px;
  font-size: 16px;
  text-align: center;
}
input:focus, input:hover {
  border: 2px solid var(--primary-accent);
  transition: ease-in-out 100ms;
  box-shadow: none;
}

button {
  font-size: 16px;
  border: none;
  background-color: var(--tartiary-accent);
  border-radius: 20px;
  padding: 1rem 2rem 1rem 2rem;
}
button:hover {
  background-color: #fff;
  border: 2px solid var(--tartiary-accent);
  transition: 150ms;
}
</style>