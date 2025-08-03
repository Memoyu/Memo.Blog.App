<script setup lang="ts">
import dayjs from "dayjs";
import { dateDiff } from "@/utils/date";

const loading = ref(false);
const finished = ref(true);

const moments = [
  {
    momentId: "11166296289181701",
    tags: [],
    content:
      "在上次总结的学习方式至今，已经是完成了严肃学习，读完了《The Rust Programming Language》\n这个过程持续了近两个月，时间线长的原因在于读书比较少，啃书能力差，后期这得多啃，提高一下。\n</br>\n接下来先进行普通训练，完成些小项目：\n1、完成软考学习网站题目的爬取；\n2、完成基于tauri的博客管理app；\n3、间隙时间学习算法，使用rust实现算法(持续到朝纲训练)；\n</br>\n完成这些后，再开始朝纲训练，达到深入的目的。",
    likes: 0,
    comments: 0,
    commentable: true,
    createTime: "2025-07-15T11:16:01.706",
    isLike: false,
    announcer: {
      userId: "8718110935678981",
      nickname: "memoyu",
      avatar: "http://oss.blog.memoyu.com/account/avatar/-9999a82392f.png",
    },
  },
  {
    momentId: "10890514784059397",
    tags: [
      "血祭",
      "缝针",
      "血祭1",
      "缝针1",
      "血祭2",
      "缝针2",
      "血祭3",
      "缝针4",
    ],
    content:
      "大清早的，为了弄个绿豆汤，给我整的缝了四针，离谱！\n<br/>\n这小水果刀直直的戳进我的手心，那一瞬间不疼，就是有点后怕。\n多年的老厨师，总算是失手一回了，总结：刀尖永远不要指向自己或者你爱的人\uD83D\uDE02。\n<br/>\n第一次被缝针，体验还算良好,\n外加双氧水冲洗+棉签擦拭让我体验感拉满,\n好在麻药还算得劲，给我麻了一整天,\n就是当晚辗转反侧......\n![Snipaste_2025-06-12_17-22-28.png](http://oss.blog.memoyu.com/articles/comments/ebf8ced2-c6e5-4176-bbb3-a8e04ffae6fc.png)\n",
    likes: 0,
    comments: 0,
    commentable: true,
    createTime: "2025-05-25T18:21:09.891",
    isLike: false,
    announcer: {
      userId: "8718110935678981",
      nickname: "memoyu",
      avatar: "http://oss.blog.memoyu.com/account/avatar/-9999a82392f.png",
    },
  },
  {
    momentId: "10890512601251845",
    tags: ["直面", "反思", "软考高级", "还在路上"],
    content:
      "#### 软考高级战况\n只能说，至少我去考了，哈哈哈哈！\n去年就报名了一次，结果临阵脱逃了......\n<br/>\n这次也没有系统的复习，但还是决定去试试水，毕竟花了钱了。\n考场在华南农业大学，离得比较近，感觉还好（是考试流程，而不是做题情况）；实际上还是挺多人缺考的，一个考场60多人，结果只来了一半的人。\n<br/>\n已经计划好了，决定下半年再去一次，教材准备好了，也开始在啃了，加油！\n<br/>\n<br/>\n#### 战报\n果然，没有系统复习，还是很难办的。\n不过案例、论文(当时字数都没写够)还是给了我一点小惊喜！\n还要继续加油呀！\n![微信图片_2025-07-06_181654_926.png](http://oss.blog.memoyu.com/articles/comments/1e3748b1-96ce-486f-986e-bd9db086e8b1.png)\n",
    likes: 1,
    comments: 0,
    commentable: true,
    createTime: "2025-05-24T20:20:36.585",
    isLike: true,
    announcer: {
      userId: "8718110935678981",
      nickname: "memoyu",
      avatar: "http://oss.blog.memoyu.com/account/avatar/-9999a82392f.png",
    },
  },
  {
    momentId: "10833417671868421",
    tags: ["学习", "学习方式", "个人提升"],
    content:
      "对文章[新技术学习不完全指北：以 Rust 为例](https://juejin.cn/post/6898953413250252814)的总结梳理，可谓是受益匪浅！\n<br/>\n前阵子是对于rust进行了的系统学习：\n1. 阅读了[Rust语言圣经](https://course.rs/about-book.html)\n2. 完成[rustlings](https://github.com/rust-lang/rustlings)练习题：[rustlings-code(进度:100%)](https://github.com/Memoyu/rustlings-code)\n3. 开发了些小工具：[rust_learn](https://github.com/Memoyu/rust_learn)\n4. 读[hrkfdn/ncspot](https://github.com/hrkfdn/ncspot)源码：[ncspot-learn(进度:20%)](https://github.com/Memoyu/ncspot-learn)\n5. 跟着[phil-opp/blog_os](https://github.com/phil-opp/blog_os)使用rust写简易的操作系统：[os-by-rust(进度:10%)](https://github.com/Memoyu/os-by-rust)\n\n虽然做了这些，但是仍然感到心里还是没底，且进度中的项也没有动力去推进(感觉在做无用功)，所以想寻求更明确的学习方式。\n直到看到这篇文章，像拨开云雾见青天，故对此做了梳理，并决定以此为依据，再次展开对rust的重新学习。\n<br/>\n![如何学习.png](http://oss.blog.memoyu.com/articles/comments/e4f09193-556d-462d-b47f-a5f471098879.png)\n",
    likes: 0,
    comments: 0,
    commentable: true,
    createTime: "2025-05-17T16:20:37.101",
    isLike: false,
    announcer: {
      userId: "8718110935678981",
      nickname: "memoyu",
      avatar: "http://oss.blog.memoyu.com/account/avatar/-9999a82392f.png",
    },
  },
  {
    momentId: "10602444780011525",
    tags: ["有感而发", "怜悯"],
    content:
      "什么样的人会在网络上找存在感？\n他的生活会是什么样的？\n他有真心朋友吗？\n他还正常吗？\n\n我不在乎答案，只是对特殊人群的怜悯。\n\n记：某理发师咬人事件\n\n",
    likes: 1,
    comments: 0,
    commentable: true,
    createTime: "2025-04-06T21:21:10.463",
    isLike: false,
    announcer: {
      userId: "8718110935678981",
      nickname: "memoyu",
      avatar: "http://oss.blog.memoyu.com/account/avatar/-9999a82392f.png",
    },
  },
  {
    momentId: "10059558799212549",
    tags: ["2024", "2025", "rust"],
    content:
      "赶在了2024的尾声跑起来了`tauri demo`\n算是好兆头吧！\n![tauri-demo.png](http://oss.blog.memoyu.com/articles/comments/3ca93faf-678d-498d-944b-f430718cf10b.png)\n",
    likes: 2,
    comments: 0,
    commentable: true,
    createTime: "2025-01-01T00:18:07.799",
    isLike: true,
    announcer: {
      userId: "8718110935678981",
      nickname: "memoyu",
      avatar: "http://oss.blog.memoyu.com/account/avatar/-9999a82392f.png",
    },
  },
  {
    momentId: "9831404063817733",
    tags: ["迷"],
    content:
      "软考当天我怯懦了，选择了缺考！\n1. 没复习\n2. 没刷题\n3. 没动力\n\n说好的规划也一直没落地，似乎总是用开发app来搪塞，哄骗自己很忙，没有时间学习！周而复始，直接就摆烂了......\n\n似乎并没有骗过自己，哈哈哈哈！\n\n哦豁，终究还是：app是半残，英语断更，文章没写，rust没入门，软考更是疲软。\n不过算是完成了一件意料之外的事，读了《活着》\n",
    likes: 2,
    comments: 0,
    commentable: true,
    createTime: "2024-11-21T17:15:22.817",
    isLike: false,
    announcer: {
      userId: "8718110935678981",
      nickname: "memoyu",
      avatar: "http://oss.blog.memoyu.com/account/avatar/-9999a82392f.png",
    },
  },
];

async function onLoad() {}
</script>

<template>
  <div class="timeline">
    <van-list
      v-model:loading="loading"
      :finished="finished"
      finished-text="没有更多了"
      @load="onLoad"
      sticky
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
                {{ dateDiff(new Date(item.createTime)) }}
              </van-tag>
            </div>
          </div>
          <div class="content-markdown">
            <preview v-model="item.content" />
          </div>

          <div class="content-extra">
            <div class="tag-list">
              <div class="tag-item" v-for="tag in item.tags" :key="tag">
                {{ tag }}
              </div>
            </div>
            <div class="sumarry-list">
              <div class="sumarry-item">
                <div class="i-carbon:chat" />
                <p>{{ item.comments }}</p>
              </div>
              <div class="sumarry-item">
                <div class="i-carbon:thumbs-up" />
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
  padding: 0 0 28px;
  overflow: unset;
  text-align: left;
  color: var(--van-cell-text-color);
}
:deep(::-webkit-scrollbar) {
  display: none;
}

.timeline {
  padding: 13px;
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
  margin: 0 0 0 25px;

  .content-head {
    --at-apply: flex justify-between;
    font-weight: 700;

    .nickname {
      font-size: var(--van-line-height-sm);
    }
  }

  .content-markdown {
    margin: 8px 0;
    border-radius: 10px;
    background: var(--van-cell-background);
    word-break: break-word;
  }

  .content-extra {
    .sumarry-list {
      --at-apply: flex space-x-20;

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
