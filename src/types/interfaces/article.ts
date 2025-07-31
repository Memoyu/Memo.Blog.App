export interface ArticleRankingItem {
  articleId: string;
  banner: string;
  title: string;
  comments: number;
  likes: number;
  views: number;
}

export interface Article {
  articleId: string;
  banner: string;
  title: string;
  comments: number;
  likes: number;
  views: number;
  updateDateTime: Date;
}
