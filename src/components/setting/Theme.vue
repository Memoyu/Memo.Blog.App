<script setup lang="ts">
const show = defineModel();
const mode = useColorMode();
const checked = ref(
  mode.value == "auto" ? "1" : mode.value == "dark" ? "2" : "3",
);

const onThemeChange = (val: string) => {
  if (val === "1") {
    mode.value = "auto";
  } else if (val === "2") {
    mode.value = "dark";
  } else if (val === "3") {
    mode.value = "light";
  }
};
</script>

<template>
  <van-dialog v-model="show" title="深色模式" @close="show = false">
    <van-radio-group v-model="checked" @change="onThemeChange">
      <van-cell-group inset>
        <van-cell title="跟随系统" clickable @click="checked = '1'">
          <template #right-icon>
            <van-radio name="1" />
          </template>
        </van-cell>
        <van-cell title="深色模式" clickable @click="checked = '2'">
          <template #right-icon>
            <van-radio name="2" />
          </template>
        </van-cell>
        <van-cell title="浅色模式" clickable @click="checked = '3'">
          <template #right-icon>
            <van-radio name="3" />
          </template>
        </van-cell>
      </van-cell-group>
    </van-radio-group>
  </van-dialog>
</template>

<style lang="less" scoped></style>
