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

export interface Tag {
  categoryId: string;
  name: string;
  articles: number;
}
