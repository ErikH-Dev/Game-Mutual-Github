<template>
    <div class="settings-container">
        <h1>Settings</h1>
        <div class="setting">
            <p>SteamID that is linked to your account.</p>
            <input v-model="steamId" type="text" placeholder="Your personal Steam ID" />
            <button @click="saveSteamId">Save</button>
        </div>
    </div>
</template>
<script>
import { ref } from 'vue';
import { useAuth0 } from "@auth0/auth0-vue";
import { useStore } from "vuex";

export default {
    name: 'SettingsPage',
    props: {
        show: {
            type: Boolean,
            default: false,
        },
    },
    setup() {
        const steamId = ref('');
        const store = useStore();
        const auth0 = useAuth0();

        const saveSteamId = async () => {
            const userId = store.state.user.id;
            const token = await auth0.auth0Client.getTokenSilently();

            fetch('http://your-api-url/api/User/AddSteamId', {
                method: 'POST',
                headers: {
                    'Content-Type': 'application/json',
                    'Authorization': 'Bearer ' + token
                },
                body: JSON.stringify({ userId, steamId: steamId.value })
            })
                .then(response => response.json())
                .then(data => console.log(data))
                .catch((error) => {
                    console.error('Error:', error);
                });
        }

        return {
            steamId,
            saveSteamId
        }
    },
};
</script>
<style>
.settings-container {
    display: flex;
    flex-direction: column;
    align-items: center;
    width: 100%;
}
.settings-container h1 {
    margin: 20px;
    font-size: 40px;
    font-weight: 300;
    color: var(--primary-accent);
}
.setting {
    display: flex;
    align-items: center;
}
</style>