<template>
    <div id="main-content" :style="mainContentStyles">
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
        <div class="pagination-container" v-if="games.length > 0">
            <button @click="prevPage" :disabled="currentPage === 1">Previous</button>
            <span>Page {{ currentPage }}</span>
            <button @click="nextPage" :disabled="games.length < 100">Next</button>
        </div>
    </div>
</template>
  
<script>
export default {
    name: 'GameContainer',
    data() {
        return {
            games: [],
            isLoading: false,
            currentPage: 1,
        };
    },
    props: {
        isSidebarOpen: Boolean,
        searchQuery: String,
        selectedUsers: Array,
    },
    methods: {
        async getGames(selectedUserIds, searchQuery, pageNumber = 1) {
            console.log('Params:', selectedUserIds, searchQuery, pageNumber);
            this.isLoading = true;
            this.currentPage = pageNumber;
            let response;
            try {
                const steamUserIdsParam = selectedUserIds && selectedUserIds.length > 0 ? selectedUserIds.join(',') : '';

                if (searchQuery && searchQuery.length > 0) {
                    response = await fetch(`https://localhost:7257/api/SteamGame/GetMutuallyOwnedGames/search/${steamUserIdsParam}/?query=${searchQuery}&pageNumber=${pageNumber}`);
                } else {
                    response = await fetch(`https://localhost:7257/api/SteamGame/GetMutuallyOwnedGames/${steamUserIdsParam}?pageNumber=${pageNumber}`);
                }

                const data = await response.json();
                this.games = data;
            } catch (error) {
                console.error('Error fetching data:', error);
            } finally {
                this.isLoading = false;
            }
        },

        getGameImageURL(appid) {
            return `https://cdn.cloudflare.steamstatic.com/steam/apps/${appid}/hero_capsule.jpg`;
        },
        handleSelectedUsersChanged(selectedUsers) {
            const selectedUsersArray = Array.from(selectedUsers);
            const steamUserIds = selectedUsersArray.map(user => user.steamUserId);
            this.getGames(steamUserIds, this.searchQuery);
        },

        nextPage() {
            this.currentPage += 1;
            this.getGames(this.$props.selectedUsers, this.searchQuery, this.currentPage);
        },

        prevPage() {
            if (this.currentPage > 1) {
                this.currentPage -= 1;
                this.getGames(this.$props.selectedUsers, this.searchQuery, this.currentPage);
            }
        },



    },
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
    content: "";
    grid-area: 1/1;
    --c: radial-gradient(farthest-side, var(--primary-accent) 92%, #0000);
    background:
        var(--c) 50% 0,
        var(--c) 50% 100%,
        var(--c) 100% 50%,
        var(--c) 0 50%;
    background-size: 24px 24px;
    background-repeat: no-repeat;
    animation: s2 1s infinite;
}

.custom-loader::before {
    margin: 8px;
    filter: hue-rotate(45deg);
    background-size: 16px 16px;
    animation-timing-function: linear
}

@keyframes s2 {
    100% {
        transform: rotate(.5turn)
    }
}

.games-container {
    display: grid;
    grid-template-columns: repeat(auto-fill, minmax(calc(15% - 10px), 1fr));
    grid-gap: 15px;
    width: 100%;
    margin-top: 15px;
}

.game-card {
    width: 100%;
    height: 0;
    padding-bottom: 120%;
    background-size: cover;
    background-position: center;
    background-color: rgba(175, 175, 175, 0.7);
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
    transform: scale(1.05);
}

.game-title {
    background-color: rgba(0, 0, 0, 0.6);
    width: 100%;
    padding: 10px;
    text-align: center;
}

.pagination-container {
    display: flex;
    flex-direction: row;
    justify-content: center;
    margin-top: 10px;
}
</style>