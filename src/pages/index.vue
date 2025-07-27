<script setup lang="ts">
import router from '@/router'
import { useUserStore } from '@/stores'

const userStore = useUserStore()
const userInfo = computed(() => userStore.userInfo)
const isLogin = computed(() => !!userInfo.value.userId)

function login() {
  if (isLogin.value)
    return

  router.push({ name: 'Login', query: { redirect: 'Profile' } })
}
</script>
<template>
    <van-button type="primary" @click="login">登录</van-button>
</template>


<route lang="json5">
{
  name: 'Home'
}
</route>
