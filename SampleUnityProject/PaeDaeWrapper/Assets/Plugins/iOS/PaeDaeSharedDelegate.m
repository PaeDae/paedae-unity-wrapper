//
//  PaeDaeSharedDelegate.m
//
//  Created by Miguel Morales on 7/19/12.
//  Copyright (c) 2012 PaeDae Inc. All rights reserved.

#import "PaeDaeSharedDelegate.h"

@implementation PaeDaeSharedDelegate
@synthesize gameObjectName;

static PaeDaeSharedDelegate *sharedDelegate = nil;

#pragma mark - static singleton access method

+ (PaeDaeSharedDelegate *) sharedDelegate
{
    if (self == [PaeDaeSharedDelegate class] && !sharedDelegate)
    {
        sharedDelegate = [[PaeDaeSharedDelegate alloc] init];
        sharedDelegate.gameObjectName = @"PaeDaeWrapper";
    }
    
    return sharedDelegate;
}

#pragma mark - PaeDaeInitDelegate callbacks

- (void) PaeDae_Initialized
{
    NSLog(@"%s - PaeDae SDK initialized", __FUNCTION__);
    UnitySendMessage([self.gameObjectName UTF8String], "PaeDaeInitialized", "");
}

- (void) PaeDae_InitializeFailed
{
    NSLog(@"%s - PaeDae SDK failed to load!", __FUNCTION__);
    UnitySendMessage([self.gameObjectName UTF8String], "PaeDaeInitializeFailed", "");
}

#pragma mark - PaeDaeAdDelegate callbacks

- (void) PaeDae_AdWillDisplay:(UIView *)view
{
    NSLog(@"%s - PaeDae ad is about to display", __FUNCTION__);
    UnitySendMessage([self.gameObjectName UTF8String], "PaeDaeAdWillDisplay", "");    
}


- (void) PaeDae_AdActionTaken
{
    //TODO!	
}

- (void) PaeDae_AdUnloaded
{
    NSLog(@"%s - PaeDae ad unloaded", __FUNCTION__);
    UnitySendMessage([self.gameObjectName UTF8String], "PaeDaeAdUnloaded", "");    
}

- (void) PaeDae_AdUnavailable
{
    NSLog(@"%s - no ad available from PaeDae", __FUNCTION__);
    UnitySendMessage([self.gameObjectName UTF8String], "PaeDaeAdUnavailable", "");
}

@end