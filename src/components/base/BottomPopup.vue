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
});
const emit = defineEmits(["confirm", "cancel"]);
const show = defineModel<boolean>();
</script>

<template>
  <van-popup
    v-model:show="show"
    :close-on-click-overlay="coco"
    round
    position="bottom"
    style="padding: 15px"
  >
    <div class="b-pop-content">
      <div v-if="props.title.length > 1" class="b-pop-top">
        {{ props.title }}
      </div>
      <slot></slot>
      <div class="b-pop-bottom">
        <div class="b-pop-bottom-group">
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
    </div>
  </van-popup>
</template>

<style lang="less" scoped>
:deep(.van-cell) {
  background: var(--van-background);
}
:deep(.van-cell::after) {
  border: none;
}

.b-pop-content {
}

.b-pop-top {
  margin-bottom: 15px;
  --at-apply: text-center font-bold;
}
.b-pop-bottom {
  margin-top: 15px;
}
.b-pop-bottom-group {
  display: flex;
  .van-button--default {
    border: none;
  }
}
</style>
