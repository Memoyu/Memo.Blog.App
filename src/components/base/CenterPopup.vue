<script setup lang="ts">
const props = defineProps({
  title: {
    type: String,
    default: "",
  },
  showConfirm: {
    type: Boolean,
    default: true,
  },
  showCancel: {
    type: Boolean,
    default: true,
  },
  coco: {
    type: Boolean,
    default: true,
  },
  width: {
    type: String,
    default: "70%",
  },
  height: {
    type: String,
    default: "auto",
  },
});
const emit = defineEmits(["confirm", "cancel"]);
const show = defineModel<boolean>();
</script>

<template>
  <van-popup
    v-model:show="show"
    :close-on-click-overlay="coco"
    round
    :style="{ padding: '15px', width, height }"
  >
    <div v-if="props.title.length > 1" class="c-pop-top">
      {{ props.title }}
    </div>
    <div class="c-pop-content">
      <slot></slot>
    </div>
    <div class="c-pop-bottom">
      <div class="c-pop-bottom-group">
        <van-button
          v-if="props.showCancel"
          :class="{ 'van-hairline--righ': props.showConfirm }"
          class="van-hairline--top"
          block
          @click="emit('cancel')"
          >取消</van-button
        >
        <van-button
          v-if="props.showConfirm"
          :class="{ 'van-hairline--left': props.showCancel }"
          class="van-hairline--top"
          block
          @click="emit('confirm')"
          >确定</van-button
        >
      </div>
    </div>
  </van-popup>
</template>

<style lang="less" scoped>
:deep(.van-cell) {
  background: var(--van-background);
  ::after {
    border: none;
  }
}
:deep(.van-cell::after) {
  border: none;
}

.c-pop-content {
}

.c-pop-top {
  margin-bottom: 15px;
  --at-apply: text-center font-bold;
}
.c-pop-bottom {
  margin-top: 15px;
}
.c-pop-bottom-group {
  display: flex;
  .van-button--default {
    border: none;
  }
}
</style>
