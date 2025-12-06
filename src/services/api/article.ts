import {
  ArticleCategory,
  ArticlePageItem,
  ArticlePageRequest,
  ArticleRankingItem,
  ArticleSummary,
  ArticleTag,
  PaginationResult,
} from "@/types/interfaces";
import Request from "@/utils/request";

export default {
  articleRanking(quota: number) {
    return Request.get<Array<ArticleRankingItem>>("article/ranking", {
      params: { quota },
    });
  },
  articlePage(request: ArticlePageRequest) {
    return Request.get<PaginationResult<ArticlePageItem>>("article/page", {
      params: request,
    });
  },
  articleSummary() {
    return Request.get<ArticleSummary>("article/summary");
  },

  articleTags(name?: string) {
    return Request.get<Array<ArticleTag>>("tag/list", {
      params: { name: name },
    });
  },
  articleCategories(name?: string) {
    return Request.get<Array<ArticleCategory>>("category/list", {
      params: { name: name },
    });
  },
};
