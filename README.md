# SentimentAnalysisDemo

Welcome to the `SentimentAnalysisDemo` repository, a demonstration of sentiment analysis integration within an ABP-based application, presented at the [ABP Dotnet CONF 2024](https://abp.io/conference/2024).

> Love the `SentimentAnalysisDemo` project? Then, please give a star(⭐)! Thanks in advance!

## About the project

This project serves as a comprehensive guide to implementing sentiment analysis in .NET applications using the ABP framework. By leveraging machine learning techniques, this demo showcases how sentiment analysis can be seamlessly integrated into your .NET projects.

In this demo application, I created an [ABP-based application](https://docs.abp.io/en/abp/8.1/Startup-Templates/Application) and integrated the [ABP's CMS Kit Module's Comment Feature](https://docs.abp.io/en/abp/latest/Modules/Cms-Kit/Comments), which provides a comment system to add a comment to any kind of resource, such as blog posts or products. By default, CMS Kit's Comment Feature does not provide spam detection and in this sample application, I simply added [spam detection](https://github.com/EngincanV/SentimentAnalysisDemo/blob/master/src/SentimentAnalysisDemo.Application/ML/SpamDetector.cs) while creating or updating a comment. Thus, whenever a comment is being added or updated, the spam detection service will validate the comment and reject it if it contains spam content otherwise it will make the other validations and save the comment.

![sentiment-analysis](https://github.com/EngincanV/SentimentAnalysisDemo/assets/43685404/61b7d4f6-736c-4900-b2e3-669452608a16)

> **Note**: The dataset used in this sample project is not ready for use in production and also it is not suitable for development purposes. It's used for spam detection in emails normally, since this is a demo application, the important thing is to build a model and applying the sentiment analysis, I did not create the dataset on my own and instead, I found the dataset from Kaggle and directly used it!

## Resources

* [Dataset](https://www.kaggle.com/datasets/ue153011/spam-mail-detection-dataset)
* [Slides](https://github.com/EngincanV/presentations/tree/main/ABP/Dotnet-Conf-2024) used in the [ABP Dotnet CONF 2024](https://abp.io/conference/2024)
