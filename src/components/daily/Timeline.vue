<script setup lang="ts">
import dayjs from "dayjs";
import { dateDiff } from "@/utils/date";
import api from "@/services/api";
import { MomentPageItem } from "@/types/interfaces";

const loading = ref(false);
const finished = ref(true);

const showOutline = ref(false);
const searchContent = ref("");
const page = ref(1);
const pageSize = 15;

const moments = ref<Array<MomentPageItem>>([]);

defineExpose({
  addClick,
});

onMounted(() => {
  // 获取动态列表
  api
    .momentPage({
      content: searchContent.value,
      page: page.value,
      size: pageSize,
    })
    .then((res) => {
      moments.value = res.items;
    });
});

function addClick() {
  console.log("新增动态");
}
</script>

<template>
  <div class="timeline">
    <van-list
      v-model:loading="loading"
      :finished="finished"
      finished-text="没有更多了"
    >
      <van-cell v-for="(item, index) in moments" :key="item.momentId">
        <div class="timeline-tail" v-show="index < moments.length - 1" />
        <div class="timeline-avatar">
          <van-image
            round
            fit="cover"
            width="30px"
            height="30px"
            :src="item.announcer.avatar"
          />
        </div>
        <div class="timeline-item-content">
          <div class="content-head">
            <div class="nickname">{{ item.announcer.nickname }}</div>
            <div class="flex">
              <div class="mr-15">
                {{ dayjs(item.createTime).format("YYYY-MM-DD HH:mm") }}
              </div>
              <van-tag type="primary">
                {{ dateDiff(item.createTime) }}
              </van-tag>
            </div>
          </div>
          <div class="content-markdown">
            <md-preview :content="item.content" />
          </div>

          <div class="content-extra">
            <div class="tag-list">
              <div class="tag-item" v-for="tag in item.tags" :key="tag">
                {{ tag }}
              </div>
            </div>
            <div class="sumarry-list">
              <div class="sumarry-item">
                <div class="i-carbon-chat" />
                <p>{{ item.comments }}</p>
              </div>
              <div class="sumarry-item">
                <div class="i-carbon-thumbs-up" />
                <p>{{ item.likes }}</p>
              </div>
            </div>
          </div>
        </div>
      </van-cell>
    </van-list>
  </div>
</template>
<style lang="less" scoped>
:deep(.van-cell) {
  padding: 0;
  background-color: unset;
  overflow: unset;
}

:deep(.van-cell:after) {
  border-bottom: none;
}
:deep(.van-cell__value) {
  padding: 0 0 24px;
  overflow: unset;
  text-align: left;
  color: var(--van-cell-text-color);
}
:deep(::-webkit-scrollbar) {
  display: none;
}

.timeline {
  padding: 10px 0 10px 10px;
}

.timeline-avatar {
  --at-apply: absolute;
  top: 16px;
  left: 4px;
  transform: translate(-50%, -50%);
}

.timeline-tail {
  position: absolute;
  top: 20px;
  left: 4px;
  height: calc(100% - 20px);
  border-left: 1px solid var(--van-black);
}

.timeline-item-content {
  margin: 0 0 0 17px;

  .content-head {
    --at-apply: flex justify-between;
    font-weight: 700;

    .nickname {
      margin-left: 7px;
      font-size: var(--van-line-height-sm);
    }
  }

  .content-markdown {
    margin: 9px 0;
    border-radius: 10px;
    background: var(--van-cell-background);
    word-break: break-word;
  }

  .content-extra {
    .sumarry-list {
      --at-apply: flex space-x-20 my-7;

      .sumarry-item {
        --at-apply: flex items-center space-x-5;
      }
    }

    .tag-list {
      display: flex;
      overflow-x: auto; /* 设置超出滚动 */

      .tag-item {
        padding: 0 6px;
        border-radius: 8px;
        color: var(--van-white);
        margin-right: 8px;
        flex-shrink: 0; /* 关键属性，防止元素缩小，确保滚动 */
        background-color: var(--van-primary-color);
      }
    }
  }
}
</style>
